docker stop mutobo-9
docker stop umbraco-db-mssql-2019
docker image rm umbraco-db
docker compose up --build
