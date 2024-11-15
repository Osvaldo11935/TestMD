# Documentação do Projeto
## Link da documentação do projecto: https://docs.google.com/document/d/e/2PACX-1vTDWdOmYI_jhYdoxY5vo_LMJmrx3LhJnPkPq_QLAFolmzgZJXF4gJSZo9mfllSaiScxxMWsiJ3d-tsm/pub
## Requisitos para Execução
- **Visual Studio**
- **PostgreSQL**

## Como Executar o Projeto
1. Execute a migration:
   ```bash
   Update-Database

# Constituição do Projeto
Deve ser alterado a connectionString que esta no arquivo de configuração(Program.cs)
```ConnectionString  a ser alterada 
Host=localhost;Database=db_test_dev;Username=root;Password=123

## Estrutura de Pastas
### Test
    #### Data 
        #### Context: Classes de contexto do banco de dados.
        #### EntityConfiguration: Configurações das entidades.
        #### Repositories (Common): Implementações dos repositórios.
        #### Interfaces
        #### IRepositories (ICommon): Interfaces dos repositórios.
    #### Models
        ##### Entities: Entidades de domínio.
        ##### Requests (Validates): DTOs para requisições com validações.
        ##### Responses: DTOs para respostas.
    #### Reports
    #### UseCases
    #### Utils

### Descrição das Pastas
#### Data: Contém todas as classes necessárias para a configuração do banco de dados.
#### Interfaces: Contém todas as interfaces utilizadas no projeto.
#### Models: Contém as entidades de domínio e os DTOs (Requests e Responses).
#### UseCases: Contém os casos de uso do projeto.
#### Utils: Contém classes auxiliares.
