# Erros em model

- Não há construtores dentro da Model, a criação de um construtor levando os parametros resolveria o problema;

- O método VerificaAprovacao não aprova caso a nota seja 5, adicionar o sinal de >= resolveria o problema;

- Não existe tratamento de dados e nenhuma validação de entrada.

# Erros em Controller

- Não possui tratamentos para devolução de BadRequest, trazendo sempre um NotFound();
