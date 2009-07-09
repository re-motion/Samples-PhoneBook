
### Search for "embel documentation" in the local confluence wiki
### (http://at-vie-dev-61)

from embellib import *

sourceProject = sys.argv[1] 
targetProject = sys.argv[2] 

def FileWriteTransplantColumns (sourceProject, targetProject, fileName):
	sourcePath, targetPath = UiPathsFromProjectsAndFileName (sourceProject, targetProject, fileName)
	FileWriteTransplantCenter (sourcePath, targetPath, kBeginColumns, kEndColumns)

def FileWriteTransplantWxeHeader (sourceProject, targetProject, fileName):
	sourcePath, targetPath = UiPathsFromProjectsAndFileName (sourceProject, targetProject, fileName)
	FileWriteTransplantCenter (sourcePath, targetPath, kBeginWxeFunction, kEndWxeFunction)	

def FileWriteTransplantActionsMenu (sourceProject, targetProject, fileName):
	sourcePath, targetPath = UiPathsFromProjectsAndFileName (sourceProject, targetProject, fileName)
	FileWriteTransplantCenter (sourcePath, targetPath, kBeginBocReferenceValue, kEndBocReferenceValue)


def FileWriteTransplantCsEmbellishment (sourceProject, targetProject, fileName):
	sourcePath, targetPath = UiPathsFromProjectsAndFileName (sourceProject, targetProject, fileName)
	FileWriteTransplantCenter (sourcePath, targetPath, kBeginCustom, kEndCustom)

def FileWriteTransplantCsEmbellishmentHandler (sourceProject, targetProject, fileName):
	sourcePath, targetPath = UiPathsFromProjectsAndFileName (sourceProject, targetProject, fileName)
	FileWriteTransplantCenter (sourcePath, targetPath, kBeginHandler, kEndHandler)


def FileWriteTransplantCsEmbellishmentEditForm (sourceProject, targetProject, fileName):
	sourcePath, targetPath = UiPathsFromProjectsAndFileName (sourceProject, targetProject, fileName)
	FileWriteTransplantCenter (sourcePath, targetPath, kBeginPageLoad, kEndPageLoad)
	FileWriteTransplantCenter (sourcePath, targetPath, kBeginDataSource, kEndDataSource)
	FileWriteTransplantCenter (sourcePath, targetPath, kBeginUserControlMultiView, kEndUserControlMultiView)
	FileWriteTransplantCenter (sourcePath, targetPath, kBeginSaveButtonClick, kEndSaveButtonClick)
	FileWriteTransplantCenter (sourcePath, targetPath, kBeginCancelButtonClick, kEndCancelButtonClick)
	FileWriteTransplantCenter (sourcePath, targetPath, kBeginCustom, kEndCustom)

def FileWriteReplaceEditHandler (sourceProject, targetProject, fileName):
	sourcePath, targetPath = UiPathsFromProjectsAndFileName (sourceProject, targetProject, fileName)
	FileWriteReplaceLineStartsWith (sourcePath, targetPath, 'if (e.Column.ItemID == "Edit"')

def FileWriteReplaceLogo (sourceProject, targetProject, fileName):
	sourcePath, targetPath = UiPathsFromProjectsAndFileName (sourceProject, targetProject, fileName)
	FileWriteReplaceLineStartsWith (sourcePath, targetPath, '<img alt="re-motion')

FileWriteTransplantColumns (sourceProject, targetProject, "EditPersonControl.ascx")
FileWriteTransplantColumns (sourceProject, targetProject, "SearchResultLocationControl.ascx") 
FileWriteTransplantColumns (sourceProject, targetProject, "SearchResultPersonControl.ascx")
FileWriteTransplantColumns (sourceProject, targetProject, "SearchResultPhoneNumberControl.ascx")

FileWriteTransplantCsEmbellishment (sourceProject, targetProject, "EditPersonControl.ascx.cs")
FileWriteTransplantCsEmbellishmentHandler (sourceProject, targetProject, "SearchResultLocationControl.ascx.cs")

FileWriteTransplantWxeHeader (sourceProject, targetProject, "EditLocationForm.aspx.cs")
FileWriteTransplantWxeHeader (sourceProject, targetProject, "EditPersonForm.aspx.cs")
FileWriteTransplantWxeHeader (sourceProject, targetProject, "EditPhoneNumberForm.aspx.cs")
FileWriteTransplantCsEmbellishmentEditForm (sourceProject, targetProject, "EditLocationForm.aspx.cs")
FileWriteTransplantCsEmbellishmentEditForm (sourceProject, targetProject, "EditPersonForm.aspx.cs")
FileWriteTransplantCsEmbellishmentEditForm (sourceProject, targetProject, "EditPhoneNumberForm.aspx.cs")

FileWriteTransplantActionsMenu (sourceProject, targetProject, "EditPersonControl.ascx")
FileWriteReplaceEditHandler (sourceProject, targetProject, "SearchResultLocationControl.ascx.cs")
FileWriteReplaceEditHandler (sourceProject, targetProject, "SearchResultPersonControl.ascx.cs")

FileWriteReplaceLogo (sourceProject, targetProject, "NavigationTabs.ascx")
