// const { resolve } = require('path');

// const context = resolve(__dirname, 'src');

// const GlobImporter = require('node-sass-glob-importer');

// // Rules
// const sassRules = {
//     loader: 'sass-loader',
//     options: {
//       importer: GlobImporter()
//     }
//   };
//   const postcssRules = {
//     loader: 'postcss-loader',
//     options: {
//       config: {
//         path: './app/postcss.config.js'
//       }
//     }
//   };
//   const cssRules = {
//     test: /\.scss$/,
//     use: [
//       'style-loader',
//       'css-loader',
//       postcssRules,
//       sassRules,
      
//     ],
// };

// module.exports = {
//   context,
//   module: {
//     rules: [
//       cssRules,
//       {
//         test: /\.js$|jsx/,
//         loader: 'babel-loader',
//         options: {
//           presets: ['minimal'],
//           plugins: [
//             ['@babel/plugin-proposal-decorators', { legacy: true }],
//             ['@babel/plugin-proposal-class-properties', { loose: true }],
//           ],
//         },
//         include: context,
//       },
//       { test: /\.css$/, use: ['style-loader', 'css-loader'] },
//       { test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])?$/, loader: "url-loader?limit=10000&mimetype=application/font-woff" },
//       { test: /\.(ttf|eot|svg|png)(\?v=[0-9]\.[0-9]\.[0-9])?$/, loader: "file-loader" },
//     ]
//   }
// };
