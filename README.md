# Employee API
API simples desenvolvida em .NET e C#, com as mais básicas operações CRUD (Create, Read,
Update, Delete), incluindo integração com o serviço de nuvem Microsoft Azure, no qual a 
API é hospedada.

O contexto é de uma tabela de empregados, na qual você consegue salvar seu Nome, email e 
informar se ele ainda está em ativa ou não.

## Restrições 
Esta API foi desenvolvidda em 5 dias. Por mais que o desenvolvimento seja simples, ainda 
é possível ocorrer inconsistência do dados caso ocorra algum problema decorrida pela falta 
de validações.

- Na requisição de adição de empregados, na sua resposta, os campos de resposta que não são 
utilizados, vem com valor nulo, sendo um problema de filtro de resposta da requisição
- Impossibilidade de adicionar um empregado com o mesmo Id

## Features
- A API possui as funcionalidades básicas de **criação, leitura, atualização e remoção** de dados (**CRUD**)
- **Persistência** de dados de forma relacional com SQL Server (Hospedado no Azure Data Base)
- API com o URL própria podendo ser acessada de qualquer lugar por conta da sua integraçao com o Microsoft Azure

# Documentação

A API possui integração com Swagger. 
As requisições poderão ser realizadas em https://employee-deploy.azurewebsites.net/swagger/ ou 
utilizando uma aplicação específica para requisições (POSTMAN, INSOMNIA).

## Entidades

### Employee (Empregado)
Propriedades:
| Nome da Propriedade | Tipo     | Descrição                          |Necessidade       |
|---------------------|----------|------------------------------------|----------------- |
| Id                  | int      | Identificação única                | Opcional         |
| Name                | string   | Nome do empregado                  | Obrigatório      |
| Email               | string   | Email do empregado                 | Obrigatório      |
| IsActive            | string   | Se o empregado está ativo          | Obrigatório      |
---
Json de geração:
~~~ json
{
  "name": "string",
  "email": "user@example.com",
  "isActive": int
}
~~~
---
Json de atualização:
~~~json
{
{
  "id": 0,
  "name": "string",
  "email": "user@example.com",
  "isActive": 0
}
}
~~~
### Rotas
> /api/Employee/GetAllEmployees -- GET Lista de empregados

> /api/Employee/GetAllEmployeesById/{id} -- GET Traz um empregado específico

> /api/Employee/AddEmployee -- PUT Adiciona Empregado

> /api/Employee/UpdateEmployee -- PATCH Atualiza Empregado específico

> /api/Employee/DeleteEmployee/{id} -- DELETE Deleta Empregado específico

---

# Funcionamento
O funcionamento da API é simples e direto. Além de poder rodar o código localmente para usar as funcionalidades, você pode acessar o link de hospedagem para o mesmo objetivo (Atualmente deploy desligado).

