# re-motion PhoneBook example

## Setting up the Solution  

1. Check out the source code to `C:\PhoneBook\` using Git
1. Open `C:\PhoneBook\PhoneBook.sln` in Visual Studio 
2. Compile the solution
3. Execute on the console
```powershell
c:\PhoneBook\Remotion\net-3.5\bin\debug\UIGen.exe /uigen:"C:\PhoneBook\PhoneBook.xml" /asmdir:"C:\PhoneBook\PhoneBook.Domain\bin\Debug"
```
4. Add the project `c:\PhoneBook\Remotion.Web\Remotion.Web.csproj` to the solution

## Setting up SQL Server 

*Note:* localhost is assumed for MSSQL

1. Create Database Phonebook in MSSQL 
2. Execute `SetupDB.sql`
3. Compile Solution
4. Set PhoneBook.Sample as Start-Project (used to fill some values in db)
5. Start
6. Set PhoneBook.Web as Start-Project 
7. Start

## Notes 

There seems to be a javascript error, which causes a break with IE10, you may press "continue", but you may also use an older IE or another browser to circumvent this message.