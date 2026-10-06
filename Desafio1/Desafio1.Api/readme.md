## API para controle de vendas e comissoes

### Tecnologias usadas:

.NET 10 + EF Core (Sqlite)

### Arquitetura:

MVVM

### Notas:

Projeto desenvolvido com intuito de calcular as comissões das vendas submetidas.

Para executar inserção de mais vendas, acionar a rota POST com os dados no mesmo formato orientado no desafio.

- Padrão de retorno sempre respeitando formato Data/Message
- Extension para tratamento de erros ModelState
- CRUD completo para busca, atualizacao, insercao e remocao de vendas.

