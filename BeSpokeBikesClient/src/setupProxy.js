﻿const { createProxyMiddleware } = require('http-proxy-middleware');

module.exports = function (app) {

    console.log('Setup Proxy');

    app.use(
        '/api',
        createProxyMiddleware({
            target: 'http://localhost:5001',
            changeOrigin: true,
        })
    );
};