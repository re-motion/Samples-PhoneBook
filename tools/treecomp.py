
# For documentation, search for "treecomp.py documentation" in Gantar's
# personal wiki


import sys
import treecomplib


gNew = sys.argv[1]
gOld = sys.argv[2]

gFileList = treecomplib.CmpWalker (gNew, gOld, [".svn"]) 


def BuildCopyCommand (filePath, new, old):
	return "copy %s %s" % (filePath, filePath.replace (new, old)) 


def PrintRemJobList (fileList):
	if fileList == []:
		print "*** NOTHING TO DO ***"
		return

	for iter in fileList:
		print "REM", iter

	print

def PrintCopyJob (fileList):
	diff = []
	xtra = []
	for iter in fileList:
		iter_split = iter.split ()
		if iter_split [0] == "diff:":
			diff.append (iter_split [1])
		elif iter_split [0] == "xtra:":
			xtra.append (iter_split [1])
		else:
			raise Exception ("trash in treecomp job-list: %s" % iter)

	print "REM diff:"
	for iter in diff:
		print BuildCopyCommand (iter, gNew, gOld) 
	print

	print "REM xtra:"
	for iter in xtra:
		print BuildCopyCommand (iter, gNew, gOld) 


PrintRemJobList (gFileList)
PrintCopyJob (gFileList)
