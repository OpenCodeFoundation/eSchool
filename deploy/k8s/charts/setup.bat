kubectl create ns eschool
kubectl label namespace eschool istio-injection=enabled
kubectl -n eschool apply -f .\eschool-gateway.yaml
helm -n eschool install mssql .\mssql\
helm -n eschool install enrolling .\enrolling\