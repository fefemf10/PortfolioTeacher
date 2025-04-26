FROM node:latest as build-stage
WORKDIR /app
COPY Portfolio.Frontend/package*.json ./
RUN npm install
COPY Portfolio.Frontend/ .
RUN npm run build

FROM nginx as production-stage
RUN mkdir /app
COPY --from=build-stage /app/dist /app
COPY Portfolio.Frontend/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80