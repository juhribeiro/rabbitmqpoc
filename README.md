# Dependências:

- [X] Docker instalado na máquina
- [X] dotnet core 2.2

### Para as aplicações funcionarem, primeiro é preciso dar build do compose:

Abra a pasta raiz do projeto e utilize o comando:
```
docker-compose build
```

### Após o compose buildar, utilize o comando abaixo para subir as aplicações:

```
docker-compose up -d
```

### Para acessar as aplicações, utilize os links abaixo:

[wonderwoman](http://localhost:7000)
[blackwidow](http://localhost:8000)