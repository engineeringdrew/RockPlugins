!function(a){function b(a){this.parent=a,this.container,this.loadbar,this.percentageContainer,this.spinner}function c(a){this.toPreload=[],this.parent=a,this.container}function d(a){this.element,this.parent=a}function e(d,e){this.element=d,this.$element=a(d),this.options=e,this.foundUrls=[],this.destroyed=!1,this.imageCounter=0,this.imageDone=0,this.alreadyLoaded=!1,this.preloadContainer=new c(this),this.overlayLoader=new b(this),this.defaultOptions={onComplete:function(){},onLoadComplete:function(){},backgroundColor:"#000",barColor:"#fff",overlayId:"qLoverlay",barHeight:1,percentage:!1,deepSearch:!0,completeAnimation:"fade",minimumTime:500},this.init()}!function(a){"use strict";function d(b){var c=a.event;return c.target=c.target||c.srcElement||b,c}var b=document.documentElement,c=function(){};b.addEventListener?c=function(a,b,c){a.addEventListener(b,c,!1)}:b.attachEvent&&(c=function(a,b,c){a[b+c]=c.handleEvent?function(){var b=d(a);c.handleEvent.call(c,b)}:function(){var b=d(a);c.call(a,b)},a.attachEvent("on"+b,a[b+c])});var e=function(){};b.removeEventListener?e=function(a,b,c){a.removeEventListener(b,c,!1)}:b.detachEvent&&(e=function(a,b,c){a.detachEvent("on"+b,a[b+c]);try{delete a[b+c]}catch(d){a[b+c]=void 0}});var f={bind:c,unbind:e};"function"==typeof define&&define.amd?define(f):"object"==typeof exports?module.exports=f:a.eventie=f}(this),function(){"use strict";function a(){}function e(a,b){for(var c=a.length;c--;)if(a[c].listener===b)return c;return-1}function f(a){return function(){return this[a].apply(this,arguments)}}var b=a.prototype,c=this,d=c.EventEmitter;b.getListeners=function(b){var d,e,c=this._getEvents();if(b instanceof RegExp){d={};for(e in c)c.hasOwnProperty(e)&&b.test(e)&&(d[e]=c[e])}else d=c[b]||(c[b]=[]);return d},b.flattenListeners=function(b){var d,c=[];for(d=0;d<b.length;d+=1)c.push(b[d].listener);return c},b.getListenersAsObject=function(b){var d,c=this.getListeners(b);return c instanceof Array&&(d={},d[b]=c),d||c},b.addListener=function(b,c){var g,d=this.getListenersAsObject(b),f="object"==typeof c;for(g in d)d.hasOwnProperty(g)&&e(d[g],c)===-1&&d[g].push(f?c:{listener:c,once:!1});return this},b.on=f("addListener"),b.addOnceListener=function(b,c){return this.addListener(b,{listener:c,once:!0})},b.once=f("addOnceListener"),b.defineEvent=function(b){return this.getListeners(b),this},b.defineEvents=function(b){for(var c=0;c<b.length;c+=1)this.defineEvent(b[c]);return this},b.removeListener=function(b,c){var f,g,d=this.getListenersAsObject(b);for(g in d)d.hasOwnProperty(g)&&(f=e(d[g],c),f!==-1&&d[g].splice(f,1));return this},b.off=f("removeListener"),b.addListeners=function(b,c){return this.manipulateListeners(!1,b,c)},b.removeListeners=function(b,c){return this.manipulateListeners(!0,b,c)},b.manipulateListeners=function(b,c,d){var e,f,g=b?this.removeListener:this.addListener,h=b?this.removeListeners:this.addListeners;if("object"!=typeof c||c instanceof RegExp)for(e=d.length;e--;)g.call(this,c,d[e]);else for(e in c)c.hasOwnProperty(e)&&(f=c[e])&&("function"==typeof f?g.call(this,e,f):h.call(this,e,f));return this},b.removeEvent=function(b){var e,c=typeof b,d=this._getEvents();if("string"===c)delete d[b];else if(b instanceof RegExp)for(e in d)d.hasOwnProperty(e)&&b.test(e)&&delete d[e];else delete this._events;return this},b.removeAllListeners=f("removeEvent"),b.emitEvent=function(b,c){var e,f,g,h,d=this.getListenersAsObject(b);for(g in d)if(d.hasOwnProperty(g))for(f=d[g].length;f--;)e=d[g][f],e.once===!0&&this.removeListener(b,e.listener),h=e.listener.apply(this,c||[]),h===this._getOnceReturnValue()&&this.removeListener(b,e.listener);return this},b.trigger=f("emitEvent"),b.emit=function(b){var c=Array.prototype.slice.call(arguments,1);return this.emitEvent(b,c)},b.setOnceReturnValue=function(b){return this._onceReturnValue=b,this},b._getOnceReturnValue=function(){return!this.hasOwnProperty("_onceReturnValue")||this._onceReturnValue},b._getEvents=function(){return this._events||(this._events={})},a.noConflict=function(){return c.EventEmitter=d,a},"function"==typeof define&&define.amd?define(function(){return a}):"object"==typeof module&&module.exports?module.exports=a:this.EventEmitter=a}.call(this),function(a,b){"use strict";"function"==typeof define&&define.amd?define(["eventEmitter/EventEmitter","eventie/eventie"],function(c,d){return b(a,c,d)}):"object"==typeof exports?module.exports=b(a,require("eventEmitter"),require("eventie")):a.imagesLoaded=b(a,a.EventEmitter,a.eventie)}(this,function(b,c,d){"use strict";function h(a,b){for(var c in b)a[c]=b[c];return a}function j(a){return"[object Array]"===i.call(a)}function k(a){var b=[];if(j(a))b=a;else if("number"==typeof a.length)for(var c=0,d=a.length;c<d;c++)b.push(a[c]);else b.push(a);return b}function l(a,b,c){if(!(this instanceof l))return new l(a,b);"string"==typeof a&&(a=document.querySelectorAll(a)),this.elements=k(a),this.options=h({},this.options),"function"==typeof b?c=b:h(this.options,b),c&&this.on("always",c),this.getImages(),e&&(this.jqDeferred=new e.Deferred);var d=this;setTimeout(function(){d.check()})}function m(a){this.img=a}function o(a){this.src=a,n[a]=this}var e=b.jQuery,f=b.console,g="undefined"!=typeof f,i=Object.prototype.toString;l.prototype=new c,l.prototype.options={},l.prototype.getImages=function(){this.images=[];for(var a=0,b=this.elements.length;a<b;a++){var c=this.elements[a];"IMG"===c.nodeName&&this.addImage(c);for(var d=c.querySelectorAll("img"),e=0,f=d.length;e<f;e++){var g=d[e];this.addImage(g)}}},l.prototype.addImage=function(a){var b=new m(a);this.images.push(b)},l.prototype.check=function(){function d(d,e){return a.options.debug&&g,a.progress(d),b++,b===c&&a.complete(),!0}var a=this,b=0,c=this.images.length;if(this.hasAnyBroken=!1,!c)return void this.complete();for(var e=0;e<c;e++){var f=this.images[e];f.on("confirm",d),f.check()}},l.prototype.progress=function(a){this.hasAnyBroken=this.hasAnyBroken||!a.isLoaded;var b=this;setTimeout(function(){b.emit("progress",b,a),b.jqDeferred&&b.jqDeferred.notify&&b.jqDeferred.notify(b,a)})},l.prototype.complete=function(){var a=this.hasAnyBroken?"fail":"done";this.isComplete=!0;var b=this;setTimeout(function(){if(b.emit(a,b),b.emit("always",b),b.jqDeferred){var c=b.hasAnyBroken?"reject":"resolve";b.jqDeferred[c](b)}})},e&&(e.fn.imagesLoaded=function(a,b){var c=new l(this,a,b);return c.jqDeferred.promise(e(this))}),m.prototype=new c,m.prototype.check=function(){var a=n[this.img.src]||new o(this.img.src);if(a.isConfirmed)return void this.confirm(a.isLoaded,"cached was confirmed");if(this.img.complete&&void 0!==this.img.naturalWidth)return void this.confirm(0!==this.img.naturalWidth,"naturalWidth");var b=this;a.on("confirm",function(a,c){return b.confirm(a.isLoaded,c),!0}),a.check()},m.prototype.confirm=function(a,b){this.isLoaded=a,this.emit("confirm",this,b)};var n={};return o.prototype=new c,o.prototype.check=function(){if(!this.isChecked){var a=new Image;d.bind(a,"load",this),d.bind(a,"error",this),a.src=this.src,this.isChecked=!0}},o.prototype.handleEvent=function(a){var b="on"+a.type;this[b]&&this[b](a)},o.prototype.onload=function(a){this.confirm(!0,"onload"),this.unbindProxyEvents(a)},o.prototype.onerror=function(a){this.confirm(!1,"onerror"),this.unbindProxyEvents(a)},o.prototype.confirm=function(a,b){this.isConfirmed=!0,this.isLoaded=a,this.emit("confirm",this,b)},o.prototype.unbindProxyEvents=function(a){d.unbind(a.target,"load",this),d.unbind(a.target,"error",this)},l}),b.prototype.createOverlay=function(){var b="absolute";if("body"==this.parent.element.tagName.toLowerCase())b="fixed";else{var c=this.parent.$element.css("position");"fixed"==c&&"absolute"==c||this.parent.$element.css("position","relative")}this.container=a("<div id='"+this.parent.options.overlayId+"'></div>").css({width:"100%",height:"100%",backgroundColor:this.parent.options.backgroundColor,backgroundPosition:"fixed",position:b,zIndex:666999,top:0,left:0}).appendTo(this.parent.$element),this.loadbar=a("<div id='qLbar'></div>").css({height:this.parent.options.barHeight+"px",marginTop:"-"+this.parent.options.barHeight/2+"px",backgroundColor:this.parent.options.barColor,width:"0%",position:"absolute",top:"50%"}).appendTo(this.container),this.spinner=a("<div id='spinner'></div>").css({}).appendTo(this.container),1==this.parent.options.percentage&&(this.percentageContainer=a("<div id='qLpercentage'></div>").text("0%").css({height:"40px",width:"100px",position:"absolute",fontSize:"3em",top:"50%",left:"50%",marginTop:"-"+(59+this.parent.options.barHeight)+"px",textAlign:"center",marginLeft:"-50px",color:this.parent.options.barColor}).appendTo(this.container)),this.parent.preloadContainer.toPreload.length&&1!=this.parent.alreadyLoaded||this.parent.destroyContainers()},b.prototype.updatePercentage=function(a){this.loadbar.stop().animate({width:a+"%",minWidth:a+"%"},200),1==this.parent.options.percentage&&this.percentageContainer.text(Math.ceil(a)+"%")},c.prototype.create=function(){this.container=a("<div></div>").appendTo("body").css({display:"none",width:0,height:0,overflow:"hidden"}),this.processQueue()},c.prototype.processQueue=function(){for(var a=0;this.toPreload.length>a;a++)this.parent.destroyed||this.preloadImage(this.toPreload[a])},c.prototype.addImage=function(a){this.toPreload.push(a)},c.prototype.preloadImage=function(a){var b=new d;b.addToPreloader(this,a),b.bindLoadEvent()},d.prototype.addToPreloader=function(b,c){this.element=a("<img />").attr("src",c),this.element.appendTo(b.container),this.parent=b.parent},d.prototype.bindLoadEvent=function(){this.parent.imageCounter++,this.element[0].ref=this,new imagesLoaded(this.element,function(a){a.elements[0].ref.completeLoading()})},d.prototype.completeLoading=function(){this.parent.imageDone++;var a=this.parent.imageDone/this.parent.imageCounter*100;this.parent.overlayLoader.updatePercentage(a),(this.parent.imageDone==this.parent.imageCounter||a>=100)&&this.parent.endLoader()},e.prototype.init=function(){this.options=a.extend({},this.defaultOptions,this.options);this.findImageInElement(this.element);if(1==this.options.deepSearch)for(var c=this.$element.find("*:not(script)"),d=0;d<c.length;d++)this.findImageInElement(c[d]);this.preloadContainer.create(),this.overlayLoader.createOverlay()},e.prototype.findImageInElement=function(b){var c="",e=a(b),f="normal";if("none"!=e.css("background-image")?(c=e.css("background-image"),f="background"):"undefined"!=typeof e.attr("src")&&"img"==b.nodeName.toLowerCase()&&(c=e.attr("src")),!this.hasGradient(c)){c=this.stripUrl(c);for(var g=c.split(", "),h=0;h<g.length;h++)if(this.validUrl(g[h])&&this.urlIsNew(g[h])){var i="";if(this.isIE()||this.isOpera())i="?rand="+Math.random(),this.preloadContainer.addImage(g[h]+i);else if("background"==f)this.preloadContainer.addImage(g[h]+i);else{var j=new d(this);j.element=e,j.bindLoadEvent()}this.foundUrls.push(g[h])}}},e.prototype.hasGradient=function(a){return a.indexOf("gradient")!=-1},e.prototype.stripUrl=function(a){return a=a.replace(/url\(\"/g,""),a=a.replace(/url\(/g,""),a=a.replace(/\"\)/g,""),a=a.replace(/\)/g,"")},e.prototype.isIE=function(){return navigator.userAgent.match(/msie/i)},e.prototype.isOpera=function(){return navigator.userAgent.match(/Opera/i)},e.prototype.validUrl=function(a){return a.length>0&&!a.match(/^(data:)/i)},e.prototype.urlIsNew=function(a){return this.foundUrls.indexOf(a)==-1},e.prototype.destroyContainers=function(){this.destroyed=!0,this.preloadContainer.container.remove(),this.overlayLoader.container.remove()},e.prototype.endLoader=function(){this.destroyed=!0,this.onLoadComplete()},e.prototype.onLoadComplete=function(){if(this.options.onLoadComplete(),"grow"==this.options.completeAnimation){var b=this.options.minimumTime;this.overlayLoader.loadbar[0].parent=this,this.overlayLoader.loadbar.stop().animate({width:"100%"},b,function(){a(this).animate({top:"0%",width:"100%",height:"100%"},500,function(){this.parent.overlayLoader.container[0].parent=this.parent,this.parent.overlayLoader.container.fadeOut(500,function(){this.parent.destroyContainers(),this.parent.options.onComplete()})})})}else{var b=this.options.minimumTime;this.overlayLoader.container[0].parent=this,this.overlayLoader.container.fadeOut(b,function(){this.parent.destroyContainers(),this.parent.options.onComplete()})}},Array.prototype.indexOf||(Array.prototype.indexOf=function(a){var b=this.length>>>0,c=Number(arguments[1])||0;for(c=c<0?Math.ceil(c):Math.floor(c),c<0&&(c+=b);c<b;c++)if(c in this&&this[c]===a)return c;return-1}),a.fn.queryLoader2=function(a){return this.each(function(){new e(this,a)})}}(jQuery);