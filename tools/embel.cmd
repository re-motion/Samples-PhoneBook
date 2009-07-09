REM Documentation is in the personal wiki, search for "embel documentation"

if not exist %1 goto bummer
if not exist %2 goto bummer
if %1 == %2 goto bummeridentical

copy %1\Classes\PhoneNumberCell.cs %2\Classes
copy %1\Classes\WebUiService.cs %2\Classes
copy %1\UI\PickLocation.aspx* %2\UI
copy %1\UI\EditPersonControl.ascx %2\UI
copy %1\UI\*.aspx.designer.cs %2\UI
copy %1\UI\*.ascx.designer.cs %2\UI
copy %1\Globalization\* %2\Globalization
copy %1\Images\* %2\Images
copy %1\global.asax* %2
copy %1\WxeFunctions.cs %2
copy %1\PhoneBook.Web.csproj %2
goto end

:bummer
echo %1 and/or %2 does not exist
goto end

:bummeridentical
echo %1 and %2 are the same directory (illegal)

:end
