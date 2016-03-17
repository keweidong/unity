@echo on
 
echo 运行客户端处理工具
echo Author: lixiaojiang
echo Date:2013.1.26

rem -----------------------------------------------------------
echo Config Client Home Path
set CLIENT_HOME=%CD%
set PROJECT_HOME=%CD%\..\
set LOADER_HOME=%CLIENT_HOME%\WebJetLoader
set Dash_HOME=%LOADER_HOME%\Genesis.exe

rem -----------------------------------------------------------
echo Run Version....
start %Dash_HOME% --gamedir "%CLIENT_HOME%" --key 4026531856 --ip 127.0.0.1 --port 9528 --heroid 2 --weaponid 0 --campid 3 --scenetype 4 --debugscript false --fullscreen false --debugloader false --showscreen false --observer true

