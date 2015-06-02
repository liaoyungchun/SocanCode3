@echo off

set target=SocanCode-Green

echo 正在清理。。。

del %target%\*.txt
del %target%\*.pdb
del %target%\*.manifest
del %target%\*.application
del %target%\*.vshost.*
del %target%\*.config

echo 完成