
### Search for "embel documentation" in the local confluence wiki
### (http://at-vie-dev-61)


import unittest
import os.path 
import sys
import string
import shutil

import unicoder

kBeginColumns = "<FixedColumns>"
kEndColumns = "</FixedColumns>"
kBeginWxeFunction = "<WxeFunction>"
kEndWxeFunction = "</WxeFunction>"
kBeginBocReferenceValue = "<remotion:BocReferenceValue"
kEndBocReferenceValue = "</remotion:BocReferenceValue>"
kBeginCustom = "// BEGIN CUSTOM"
kEndCustom = "// END CUSTOM"
kBeginPageLoad = "void Page_Load"
kEndPageLoad = "// END Page_Load"
kBeginDataSource = "IBusinessObjectDataSourceControl DataSource"
kEndDataSource = "// END DataSource"
kBeginUserControlMultiView = "TabbedMultiView UserControlMultiView"
kEndUserControlMultiView = "// END UserControlMultiView"
kBeginSaveButtonClick = "void SaveButton_Click"
kEndSaveButtonClick = "// END SaveButton_Click"
kBeginCancelButtonClick = "void CancelButton_Click"
kEndCancelButtonClick = "// END CancelButton_Click"
kBeginHandler = "// BEGIN HANDLER"
kEndHandler = "// END HANDLER"


class NoBeginException (Exception):
	pass

class NoEndException (Exception):
	pass

class IdenticalFilesException (Exception):
	pass

class FoundNothingToSubstituteException (Exception):
	pass

def ThreeSplit (text, mBegin, mEnd):
	foundBegin = text.find (mBegin)
	if foundBegin == -1:
		raise NoBeginException ()
	foundEnd = text.find (mEnd)
	if foundEnd == -1:
		raise NoEndException ()
	pre = text [: foundBegin ]
	center = text [foundBegin : foundEnd + len (mEnd)]
	post = text [foundEnd + len (mEnd) :]
	return pre, center, post  

def TransplantCenter (sourceText, targetText, mBegin, mEnd):
	preSource, centerSource, postSource = ThreeSplit (sourceText, mBegin, mEnd)
	preTarget, centerTarget, postTarget = ThreeSplit (targetText, mBegin, mEnd)
	return preTarget + centerSource + postTarget

def NormalizeAndComparePaths (sourcePath, targetPath):
	sourcePathNorm = os.path.abspath (sourcePath)
	targetPathNorm = os.path.abspath (targetPath)

	if sourcePathNorm == targetPathNorm:
		raise IdenticalFilesException ()

	return sourcePathNorm, targetPathNorm


def FileTransplantCenter (sourcePath, targetPath, mBegin, mEnd):
	sourcePathNorm, targetPathNorm = NormalizeAndComparePaths (sourcePath, targetPath)
	# sourceText = open (sourcePathNorm).read()
	# targetText = open (targetPathNorm).read()
	sourceText = unicoder.UnicodeSmartRead (sourcePathNorm)
	targetText = unicoder.UnicodeSmartRead (targetPathNorm)
	return TransplantCenter (sourceText, targetText, mBegin, mEnd)
	
def FileWriteTransplantCenter (sourcePath, targetPath, mBegin, mEnd):
	text = FileTransplantCenter (sourcePath, targetPath, mBegin, mEnd)
	# open (targetPath, "w").write (text)
	unicoder.UnicodeSmartWrite (targetPath, text)

def UiPathsFromProjectsAndFileName (sourceProject, targetProject, fileName):
	sourcePath = os.path.abspath (sourceProject + "\\UI\\" + fileName)
	targetPath = os.path.abspath (targetProject + "\\UI\\" + fileName)
	return sourcePath, targetPath


def ReplaceLineStartsWith (sourceText, targetText, startsWith):
	rememberSubstitute = None 
	tempText = []
	for iterLines in sourceText.split ("\n"):
		if iterLines.strip ().startswith (startsWith):
			rememberSubstitute = iterLines
			break

	if rememberSubstitute is None:
		raise FoundNothingToSubstituteException ()

	didSubstitute = None
	for iterLines in targetText.split ("\n"):
		if iterLines.strip ().startswith (startsWith):
			tempText.append (rememberSubstitute)
			didSubstitute = rememberSubstitute
		else:
			tempText.append (iterLines)

	if didSubstitute is None:
		raise FoundNothingToSubstituteException ()

	return string.join (tempText, "\n")

def FileReplaceLineStartsWith (sourcePath, targetPath, startsWith):
	sourcePathNorm, targetPathNorm = NormalizeAndComparePaths (sourcePath, targetPath)

	# sourceText = open (sourcePathNorm).read ()
	# targetText = open (targetPathNorm).read ()
	sourceText = unicoder.UnicodeSmartRead (sourcePathNorm)
	targetText = unicoder.UnicodeSmartRead (targetPathNorm)
	return ReplaceLineStartsWith (sourceText, targetText, startsWith)

def FileWriteReplaceLineStartsWith (sourcePath, targetPath, startsWith):
	text = FileReplaceLineStartsWith (sourcePath, targetPath, startsWith)
	# open (targetPath, "w").write (text)
	unicoder.UnicodeSmartWrite (targetPath, text)



if __name__ == "__main__":
	kEmptyText = kBeginColumns + kEndColumns
	kAlmostEmptyText = "alpha" + kEmptyText + "omega"
        kExpectedTargetText ="alpha\n<FixedColumns>\ndouble-u\n</FixedColumns>\nomega\n" 
	kExpectedLinesTargetText = "foo\nbar\nbaz\n  marker spam\nsan\nshi\n"

	class TestThis (unittest.TestCase):
		def testThreeSplitEmpty (self):
			text = kEmptyText 
			pre, center, post = ThreeSplit (text, kBeginColumns, kEndColumns)
			assert pre == ""
			assert center == text
			assert post == ""

		def testThreeSplitAlmostEmpty (self):
			text = kAlmostEmptyText
			pre, center, post = ThreeSplit (text, kBeginColumns, kEndColumns)
			assert pre == "alpha"
			assert center == kEmptyText
			assert post == "omega"

		def testThreeSplitMissingBegin (self):
			text = kEndColumns
			self.assertRaises (NoBeginException, ThreeSplit, text, kBeginColumns, kEndColumns)
			
		def testThreeSplitMissingEnd (self):
			text = kBeginColumns
			self.assertRaises (NoEndException, ThreeSplit, text, kBeginColumns, kEndColumns)

		def testTransplantCenterEmpty (self):
			source = kEmptyText 
			target = kEmptyText 
			textTarget = TransplantCenter (source, target, kBeginColumns, kEndColumns)

			assert textTarget == kEmptyText

		def testTransplantCenter (self):
			source = "ichi" + kBeginColumns + "ni" + kEndColumns + "san"
			target = "one" + kBeginColumns + "two" + kEndColumns + "three"
			textTarget = TransplantCenter (source, target, kBeginColumns, kEndColumns)

			assert textTarget == "one" + kBeginColumns + "ni" + kEndColumns + "three"

		def testFileTransplantCenterIdenticalFiles (self):
			self.assertRaises (IdenticalFilesException, FileTransplantCenter, r"dummy\subdummy\..\foobar.txt", r".\dummy\foobar.txt", kBeginColumns, kEndColumns)

		def testFileTransplantCenter (self):
			shutil.copyfile (r"dummy\target-orig.txt", r"dummy\target.txt")
			targetText = FileTransplantCenter (r"dummy\source.txt", r"dummy\target.txt", kBeginColumns, kEndColumns)
			assert targetText == kExpectedTargetText 

		def testReplaceLineStartsWithNoSubstitute0 (self):
			source = "ichi\nni\nsan\nshi"
			target = "foo\nbar\nbaz"
			self.assertRaises (FoundNothingToSubstituteException, ReplaceLineStartsWith, source, target, "whatever")

		def testReplaceLineStartsWithNoSubstitute1 (self):
			source = "ichi\nni\nsan\nshi"
			target = "foo\nbar\nbaz"
			self.assertRaises (FoundNothingToSubstituteException, ReplaceLineStartsWith, source, target, "ni")

		def testReplaceLineStartsWith (self):
			source = "ichi\n  ni spam\nsan\nshi"
			target = "foo\nbar\nbaz\n     ni\nquux\n"
			textTarget = ReplaceLineStartsWith (source, target, "ni")
			assert textTarget == "foo\nbar\nbaz\n  ni spam\nquux\n"

		def testFileReplaceLineStartsWith (self):
			shutil.copyfile (r"dummy\lines-target-orig.txt", r"dummy\lines-target.txt")
			text = FileReplaceLineStartsWith (r"dummy\lines-source.txt", r"dummy\lines-target.txt", "marker")
			assert text == kExpectedLinesTargetText 

		def testFileWriteTransplantCenter (self):
			shutil.copyfile (r"dummy\target-orig.txt", r"dummy\target.txt")
			FileWriteTransplantCenter (r"dummy\source.txt", r"dummy\target.txt", kBeginColumns, kEndColumns)
			assert open (r"dummy\target.txt").read () == kExpectedTargetText

		def testFileWriteReplaceLineStartsWith (self):
			shutil.copyfile (r"dummy\lines-target-orig.txt", r"dummy\lines-target.txt")
			FileWriteReplaceLineStartsWith (r"dummy\lines-source.txt", r"dummy\lines-target.txt", "marker")
			assert open (r"dummy\lines-target.txt").read () == kExpectedLinesTargetText

	unittest.main ()



	


