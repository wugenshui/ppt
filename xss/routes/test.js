var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  // 阻止浏览器拦截XSS攻击
  //res.set("X-XSS-Protection",0)
  res.render('test', { xss: req.query.xss });	
});

module.exports = router;
