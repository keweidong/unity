log = require("./log.js")
var name1 = 'fdfd';
var name2 = 'fdfdfdfdf';

log.disklog("warn", "fuck %s, %s", [name1, name2]); 
log.disklog("warn", "fuck %d, %d", [1024, 9527]); 
log.disklog("warn", "fuck %d, %s", [1024, name1]); 
log.disklog("debug", "fuck %d, %s", [1024, name1]); 
var mylog = log.init("cache");

mylog.cachelog("fuck %d, %s", [1311333, name1]); 
mylog.tick();
mylog.disklog("warn", "fuck %s, %s", [name1, name2]); 
mylog.disklog("warn", "fuck %d, %d", [1024, 9527]); 
mylog.disklog("warn", "fuck %d, %s", [1024, name1]); 
mylog.disklog("debug", "fuck %d, %s", [1024, name1]); 
mylog.cachelog("fuck %d, %s", [33434, name1]); 
mylog.cachelog("fuck %d, %s", [3434, name1]); 
mylog.cachelog("fuck %d, %s", [33343, name1]); 
mylog.cachelog("fuck %d, %s", [3883, name1]); 
mylog.tick();
mylog.cachelog("fuck %d, %s", [33343, name1]); 
mylog.cachelog("fuck %d, %s", [3883, name1]); 
mylog.tick();
