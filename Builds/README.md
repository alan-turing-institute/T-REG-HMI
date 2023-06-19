# Building and deploying T-REG-HMI

## WebGL

To deploy the app on Microsoft Azure Cloud using this method you will need:
* An Azure subscription
* A dockerhub account
* Docker desktop installed on your machine.

### Building the WebGL app.

In Unity "Build Settings", set the target to WebGL, and click "Switch Platform".
You may need to resolve some warning related to colour ranges - uncheck the box that it tells you to.

* Save the build to "T-REG-HMI" in the `Builds/WebGL` directory.

### Build and push the docker image

* Run the following commands from the `Builds/WebGL` directory:
```
docker build -t <dockerhub-username>/t-reg-hmi:latest .
docker push <dockerhub-username>/t-reg-hmi:latest
```

### Creating the webapp

* In Azure, create a "Web App", select "docker", then "dockerhub" as the image source, and specify the name of your docker image.
The name that you choose for the webapp will become the first part of your URL, i.e.
`http://<my-trex-app>.azurewebsites.net`
* It will take about 5-10 minutes the first time for the app to be deployed, as Azure needs to pull the image from Dockerhub.
