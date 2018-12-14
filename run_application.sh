#!/usr/bin/env bash

docker container run -d --rm -p 5440:5432 -e POSTGRES_USER=db_user -e POSTGRES_DB=pg_db \
        --name pg_db postgres:10

counter=0
while true;do
    result=$(pg_isready -d pg_db -h localhost -p 5440 -U db_user)
    echo "$result"
    if [[ $result == *"accepting"* ]]; then
        echo "postgres was successfully started"
        break
    elif [[ counter -gt 100 ]]; then
        echo "postgres failed"
        exit 1
    fi
    ((counter++))
    sleep 1s
done

ASPNETCORE_ENVIRONMENT=Development
export ASPNETCORE_ENVIRONMENT

echo "$ASPNETCORE_ENVIRONMENT"

cd ./dotnet_shared_volume
dotnet run 