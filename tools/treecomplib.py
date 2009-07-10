
# For documentation, search for "treecomp.py documentation" in Gantar's
# personal wiki

import unittest
import filecmp
import os
import os.path




class MissingFileOrDirectoryException (Exception):
	def __init__(self, dir, missingList):
		self.dir = dir
		self.missingList = missingList 
	def __str__(self):
		out = "Files missing from old (2nd) directory:\n"
		for iter in self.missingList:
			out += "- %s\\%s\n" % (self.dir, iter)
		return out
		

def CmpWalkerCore (new, old, ignore, accu):
	cmp = filecmp.dircmp (new, old, ignore)
	if len (cmp.right_only) > 0:
		raise MissingFileOrDirectoryException (old, cmp.right_only)
	for xtra in cmp.left_only:
		accu.append ("xtra: %s\\%s" % (new, xtra))
	for diff in cmp.diff_files:
		accu.append ("diff: %s\\%s" % (new, diff))
	for dir in cmp.common_dirs:
		CmpWalkerCore (new + "\\" + dir, old + "\\" + dir, ignore, accu)



def CmpWalker (new, old, ignore):
	accu = []
	CmpWalkerCore (new, old, ignore, accu)
	return accu

if __name__ == '__main__':
	class TestThis (unittest.TestCase):
		def setUp (self):
			pass

		def test (self):
			cmpd = filecmp.dircmp ("dummy", "dummy", [".svn"])
			assert cmpd.common_dirs == ["subdummy"]

		def testCmpWalkerEqual (self):
			new = r"trees\equal-trees\new"
			old = r"trees\equal-trees\old"
			assert [] == CmpWalker (new, old, [".svn"])

		def testCmpWalkerUnequal (self):
			new = r"trees\unequal-trees\new"
			old = r"trees\unequal-trees\old"
			cmp = CmpWalker (new, old, [".svn"])
			assert cmp[0] == r"xtra: trees\unequal-trees\new\extra.txt"
			assert cmp[1] == r"diff: trees\unequal-trees\new\lolek\lolz.txt"

		def testCmpWalkerBogus (self):
			new = r"trees\bogus-trees\new"
			old = r"trees\bogus-trees\old"
			self.assertRaises (MissingFileOrDirectoryException, CmpWalker, new, old, [".svn"])

	unittest.main ()
