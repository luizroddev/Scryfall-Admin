### [Versão 1.1.0] - Lançada em 11 de outubro de 2023

### Adicionado

- Adicionados testes para a classe `CartaImagensUris`
  - Testes de validação para `CartaImagensUris` propriedades

- Adicionados testes para a classe `CartaLegalidades`
  - Testes de validação para `CartaLegalidades` propriedades

- Adicionados testes para a classe `Carta`
  - Testes de validação para `Carta` propriedades

- Adicionados testes para a classe `Colecao`
  - Testes de validação para `Colecao` propriedades

- Adicionados testes para os controladores
  - Testes para as ações dos controladores `CartaImagensUrisController`, `CartaLegalidadesController`, `CartasController`, e `ColecaosController`

- Adicionados testes com o uso do Entity Framework Core e xUnit para testar o comportamento dos controladores

### Corrigido

- Corrigidos erros nas classes de teste para garantir a validação correta das propriedades

### Atualizado

- Atualizada a documentação para os testes com comentários explicativos

### Versão 1.0.0 - Lançada em 7 de outubro de 2023
- Refatoração: Adicionou chaves estrangeiras e renomeou modelos.

- Novo recurso: Criou modelo, visualização e controlador para cartas com imagens URI.

- Novo recurso: Criou modelo, visualização e controlador para a legalidade das cartas.

- Novo recurso: Adicionou variáveis de chaves estrangeiras para imagens URI e legalidades.

- Novo recurso: Implementou caching e consultas de chaves estrangeiras nas visualizações.

- Novo recurso: Criou visualizações para cartas e implementou seleção de chaves estrangeiras.

- Correção: Removidas migrações não utilizadas e atualizado o modelo de banco de dados.

- Novo recurso: Implementou novos dbsets e criou relacionamentos entre entidades.

- Novo recurso: Adicionou serviço de cache em memória.
