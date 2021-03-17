FROM nginx:alpine
COPY ./config/nginx.conf /etc/nginx/conf.d/default.conf


# Use the following commands to build the image and run the container (Run from the root directory)

# 1. Build the project
# ng build --watch --delete-output-path false

# 2. Build the docker image
# docker build -t nginx-angular -f nginx.dev.dockerfile .

# 3. Run the docker container
# docker container run -p 8080:80 -v $(pwd)/dist:/usr/share/nginx/html nginx-angular