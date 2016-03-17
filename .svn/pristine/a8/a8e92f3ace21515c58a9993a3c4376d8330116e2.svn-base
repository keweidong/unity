//log system for node.js
//by kevin cui
//qq:119862170

var fs = require("fs");
var path = require("path");
var util = require("util");
var buffer = require("buffer");
var vs = require("./sprintf-0.7-beta1.js");
var log = {};

Date.prototype.Format = function(fmt)   
{ //author: meizz   
  var o = {   
    "M+" : this.getMonth()+1,                 //月份   
    "d+" : this.getDate(),                    //日   
    "h+" : this.getHours(),                   //小时   
    "m+" : this.getMinutes(),                 //分   
    "s+" : this.getSeconds(),                 //秒   
    "q+" : Math.floor((this.getMonth()+3)/3), //季度   
    "S"  : this.getMilliseconds()             //毫秒   
  };   
  if(/(y+)/.test(fmt))   
    fmt=fmt.replace(RegExp.$1, (this.getFullYear()+"").substr(4 - RegExp.$1.length));   
  for(var k in o)   
    if(new RegExp("("+ k +")").test(fmt))   
  fmt = fmt.replace(RegExp.$1, (RegExp.$1.length==1) ? (o[k]) : (("00"+ o[k]).substr((""+ o[k]).length)));   
  return fmt;   
}

log.buf = {};

function Log() {
}
log.init = function(filename){
    //log = new Log();
    log.buf = new Buffer(8192);
    log.writepos = 0;
    log.name = filename;
    return log;
}
log.flushlog = function() {
    var dexist = fs.exists("./Log/");
    if (dexist === false){
	fs.mkdir("./Log/");
    }
    var fname = genfilename(log.name);
    function genfilename(fname){
	var cur = new Date();
	var time = cur.Format("yyyy-MM-dd");
	return "./Log/" + fname + "_" + time + "_" + process.pid + ".log";
    }
    fs.open(fname, "a", 0644, function(e, fd) {
	if (e) throw e;
	fs.write(fd, log.buf.toString('utf8', 0, log.writepos), 0, 'utf8', function(e){
	    if (e) throw e;
	    fs.closeSync(fd);
	});
	log.writepos = 0;
    });
}
log.cachelog = function(fmt, argv) {
    var data = vs.vsprintf(fmt, argv);
    console.log(data);
    data = data + "(" + (new Date()).Format("yyyy-MM-dd-hh-mm-ss-S");
    data = data + ")\n";
    var tmpbuf = new Buffer(data);
    log.buf.write(data, log.writepos);
    log.writepos += tmpbuf.length
}
log.tick = function() {
    this.flushlog();
}
log.disklog = function(name, fmt, argv){
    var dexist = fs.existsSync("./Log/");
    if (dexist === false){
	fs.mkdirSync("./Log/");
    }
    var filename = genfilename(name);
    function genfilename(name){
	var cur = new Date();
	var time = cur.Format("yyyy-MM-dd");
	return "./Log/" + name + "_" + time + "_" + process.pid + ".log";
    }
    fs.open(filename, "a", 0644, function(e, fd) {
	if (e) throw e;
	fmt = fmt + "(" + (new Date()).Format("yyyy-MM-dd-hh-mm-ss-S");
	fmt = fmt + ")\n";
	var data = vs.vsprintf(fmt, argv);
	console.log(data);
	fs.write(fd, data, 0, 'utf8', function(e){
	    if (e) throw e;
	    fs.closeSync(fd);
	})
    });
}
module.exports = log;


