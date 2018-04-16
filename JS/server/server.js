var express = require("express")
var bodyParser = require("body-parser")
var app = express()
app.use(bodyParser.urlencoded({ extended: false }))
var hostName = "127.0.0.1"
var port = 8080
var data = [] // 存储的消息列表

app.all("*", function(request, response, next) {
  response.header("Access-Control-Allow-Origin", "*") // 告诉浏览器所有的域都可以访问该请求
  response.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept")
  response.header("Access-Control-Allow-Methods", "PUT,POST,GET,DELETE,OPTIONS")
  response.header("X-Powered-By", " 3.2.1")
  response.header("Content-Type", "application/json;charset=utf-8")
  next()
})

// 回调函数参数:客户端发送请求,服务端的响应
app.get("/list", function(request, response) {
  response.send(data)
})

app.post("/save", function(request, response) {
  console.log("save请求参数：", request.body)
  data.push(request.body)
  var result = { code: 200, msg: "保存成功" }
  response.send(result)
})

app.listen(port, hostName, function() {
  console.log(`服务器运行在http://${hostName}:${port}`)
})
