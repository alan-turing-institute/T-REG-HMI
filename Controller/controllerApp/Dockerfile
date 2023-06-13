FROM turingcropapp/webappbase:latest

RUN mkdir controller
COPY index.html controller/index.html
COPY joy.js controller/joy.js
WORKDIR controller
ENTRYPOINT ["python3","-m","http.server","8001"]
