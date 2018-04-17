const path = require("path")
const HtmlWebpackPlugin = require("html-webpack-plugin")

module.exports = {
  entry: "./src/index.js",
  output: {
    path: path.resolve(__dirname, "dist"),
    filename: "bundle.js"
  },
  module: {
    rules: [
      { test: /\.vue$/, loader: ["vue-loader"], exclude: /node_modules/ },
      { test: /\.css$/, use: ["style-loader", "css-loader", "postcss-loader"] }
      //   { test: /\.(png|svg|jpg|gif|ico)$/, use: ["file-loader"] },
    ]
  },
  plugins: [new HtmlWebpackPlugin({ template: "src/index.html" })],
  mode: "production"
}
