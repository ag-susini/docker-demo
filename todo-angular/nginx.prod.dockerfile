##### Stage 1
# Setup base image
FROM node:latest AS node
# Set the working directory
WORKDIR /app
# Copy the package.json to the working directory
COPY package.json package.json
# Install packages from the package.json file
RUN npm install --force
# Copy all the code from the root dirtory into the image
COPY . . 
# Run the build command, use the -- to escape --prod parameter
RUN npm run build -- --prod

##### Stage 2
# Setup base image
FROM nginx:alpine 
# Copy from output from node container into this one
COPY --from=node /app/dist/todo-angular /usr/share/nginx/html
# Add the nginx config into the container
COPY ./config/nginx.conf /etc/nginx/conf.d/default.conf

# docker build -t nginx-angular -f nginx.prod.dockerfile .
# docker run -p 8080:80 nginx-angular