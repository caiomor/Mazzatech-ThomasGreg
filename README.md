# Mazzatech-ThomasGreg
API Thomas Greg Mazzatech

Este sistema foi implementado como uma solução CRUD (Criar, Ler, Atualizar, Excluir) para simplificar o registro e upload de logotipo para os clientes. As solicitações HTTP são responsáveis ​​pela coordenação eficaz, possibilitada por meio de duas APIs principais: as de Cliente e de Local, que possuem seus endpoints para tarefas específicas.

<h3>Auth:</h3>
<ul>
  <li>POST: Realiza a autenticação do usuário e gera um token para ser usado nas chamadas dos métodos abaixo</li>
</ul>

<h3>Clientes:</h3>
<ul>
  <li>GET: Recupera os dados de um cliente específico.</li>
  <li>POST: Realiza o cadastro de um novo cliente.</li>
  <li>PUT: Atualiza os dados de um cliente existente.</li>
  <li>DELETE: Remove um cliente do sistema.</li>
</ul>

<h3>Logradouros:</h3>
<ul>
  <li>GET: Obtem informações de um logradouro específico associado a um cliente.</li>
  <li>GET All: Lista todos os logradouros vinculados a um cliente.</li>
  <li>POST: Adiciona um novo logradouro para um cliente.</li>
  <li>PUT: Modifica os detalhes de um logradouro específico de um cliente.</li>
  <li>DELETE: Exclui um logradouro da lista de um cliente.</li>
</ul>

<h1>Guia de Instalação</h1>
<pre><code>
1. Inicie criando o banco de dados SQL em seu ambiente local e execute o arquivo "Scripts.txt" localizado na raiz do diretório.
<br>
2. faça o clone ou copie o codigo do diretório para seu ambiente local.
<br>
3. Acesse o arquivo 'appsettings.json' e substitua o texto {String de Conexão} pela sua string de conexão.
<br>
4. Rode o projeto ThomasGreg.API e a pagina padrão do swagger deve abrir contendo todos os métodos criados.
<br>
5. Rode primeiramente o método Auth (post) informando Username:"User" Password: "Password", Um token deve ser gerado,
   e o mesmo deve ser informado dentro da aba authorize (topo da pagina) da seguinte maneira: Bearer {token gerado}
<br>
6. Após autorização os métodos da API passaram a funcionar de maneira autenticada fazendo o CRUD de acordo com o solicitado.

</code></pre>

