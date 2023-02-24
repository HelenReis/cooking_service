const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
  entry: './src/index.js',
  experiments: {
    outputModule: true,
  },
  output: {
    filename: 'bundle.js',
    path: __dirname + '/dist',
    module: true
  },
  module: {
    rules: [
      {
        test: /\.html$/,
        use: 'html-loader'
      }
      // {
      //   test: /\.js$/,
      //   exclude: /node_modules/,
      //   use: {
      //     loader: 'babel-loader',
      //     options: {
      //       presets: ['@babel/preset-env'],
      //     },
      //   },
      // },
    ],
  },
  // plugins: [
  //   new HtmlWebpackPlugin({
  //     template: './src/index.html',
  //   }),
  // ],
};