/// <reference types="vitest" />
import { defineConfig, loadEnv } from 'vite';
import react from '@vitejs/plugin-react';
import viteTsconfigPaths from 'vite-tsconfig-paths';
import svgrPlugin from 'vite-plugin-svgr';

// https://vitejs.dev/config/
export default ({mode}) => {
    process.env = {...process.env, ...loadEnv(mode, process.cwd())}
    
    return defineConfig({
        plugins: [react(), viteTsconfigPaths(), svgrPlugin()],
        server: {
            port: parseInt(process.env.VITE_PORT),
            proxy: {
                "/api" : {
                    target: "http://localhost:5001",
                    changeOrigin: true,
                    secure: false
                }
            }
        },
        test: {
            globals: true,
            environment: 'jsdom',
            setupFiles: './src/Frontend/setupTests.ts',
            coverage: {
                provider: "c8",
                reporter: ['text', 'html'],
                exclude: [
                    'node_modules/',
                    'src/Frontend/setupTests.ts',
                ],
            },
        },
    });
}