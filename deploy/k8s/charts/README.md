# Deployment Guideline

1. Install istio with demo profile from [getting started](https://istio.io/latest/docs/setup/getting-started/) tutorial.
2. Create new namespace, eschool - `kubectl create ns eschool`
3. Enable istio sidecar injection in eschool namespace - `kubectl label namespace eschool istio-injection=enabled`

4. Deploy the eschool gateway `kubectl -n eschool apply -f .\eschool-gateway.yaml`

5. Deploy mssql - `helm -n eschool install mssql .\mssql\`

6. Deploy enrolling service - `helm -n eschool install enrolling .\enrolling\`

7. After the deployment is completed visit [http://localhost/enrolling-api/swagger/index.html](http://localhost/enrolling-api/swagger/index.html)