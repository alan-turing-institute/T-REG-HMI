FROM    mhart/alpine-node

RUN     npm install -g http-server


ADD . /site
WORKDIR /site
RUN ./unzip_files.sh

# The default port of the application
EXPOSE  8080

CMD ["http-server", "--cors", "-p8080", "/site/T-REG-HMI"]