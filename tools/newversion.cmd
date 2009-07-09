rmdir /s /q scratch
mkdir scratch
7z x -y -oscratch \\at-vie-dc-02\development\build\Remotion\Framework\build\Remotion_%2.zip
del /s /q  %1\Remotion\net-3.5\bin\debug
copy scratch\net-3.5\bin\debug\*  %1\Remotion\net-3.5\bin\debug

