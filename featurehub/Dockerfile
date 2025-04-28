FROM eclipse-temurin:17-jre
WORKDIR /app
ADD https://central.maven.org/maven2/io/featurehub/edge/edge-main/1.5.9/edge-main-1.5.9.jar app.jar
EXPOSE 8085
ENTRYPOINT ["sh", "-c", "java -jar app.jar --server.port=$PORT"]
