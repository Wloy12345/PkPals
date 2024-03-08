// vite.config.js
export default {
    build: {
      rollupOptions: {
        input: {
          main: '/index.html',
          about: '/aboutUs.html'
        }
      }
    }
  }