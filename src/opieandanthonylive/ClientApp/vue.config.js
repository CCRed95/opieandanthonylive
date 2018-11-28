module.exports = {
  css: {
    loaderOptions: {
      sass: {
        includePaths: ['./node_modules']
      },
    }
  },
  devServer: {
    proxy: {
      '/api': {
        target: 'https://localhost:44318',
      },
    },
  },
};