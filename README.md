# ⚽ Clubes-de-Futebol

Programa **console** em **C# (.NET 8)** para gerenciar clubes de futebol, permitindo cadastrar clubes, jogadores, técnicos, simular partidas e armazenar os dados em arquivos XML.

---

## 💡 Objetivo

Oferecer uma solução simples para gerenciamento de dados relacionados a clubes de futebol, utilizando uma estrutura de código modular, persistência em XML e navegação por menus no console.

---

## 🏗️ Estrutura do projeto

.
├── DadosXml/ # Armazenamento de dados em XML (Clubes, Jogadores, Técnicos, Partidas)
├── Data/ # Gerencia leitura e escrita dos dados
├── Menus/ # Controle e navegação dos menus no console
├── Models/ # Modelos das entidades (Clube, Jogador, Tecnico, Partida)
├── src/ # Código principal com funções organizadas
├── Program.cs # Ponto de entrada principal do programa
└── README.md # Documentação

yaml
Copiar
Editar

---

## ⚙️ Funcionalidades principais

- 📄 **Cadastro** de clubes, jogadores e técnicos
- 🤝 **Associação** de jogadores e técnicos aos clubes
- 🏟️ **Simulação de partidas** entre clubes
- 🗂️ **Listagem e exclusão** de clubes, jogadores e técnicos
- 💾 **Persistência de dados em XML**, garantindo registros salvos entre execuções

---

## 💾 Sobre os dados

- Os dados são armazenados em arquivos XML dentro da pasta `DadosXml/`, permitindo manter os registros mesmo após fechar o programa.
- O projeto já inclui **dados pré-definidos** no XML para facilitar o uso inicial.
- ⚠️ **Importante**: caso os arquivos XML sejam excluídos ou corrompidos, o programa carrega automaticamente dados padrão definidos na classe `Program`, garantindo que o sistema continue funcionando normalmente.

---

## 🚀 Como executar

### Pré-requisitos

- .NET 8 SDK instalado (ou versão compatível)

### Passos

```bash
git clone https://github.com/aTu44/Clubes-de-Futebol.git
cd Clubes-de-Futebol
dotnet build
dotnet run

```
Em seguida, utilize o menu no console para gerenciar clubes, jogadores, técnicos e simular partidas.

🤝 Contribuição
Contribuições são bem-vindas! Para colaborar:

Faça um fork do projeto.

Crie uma branch: feature/sua-funcionalidade.

Faça commit das alterações.

Abra um Pull Request.

📝 Licença
Este projeto ainda não possui uma licença definida. Caso deseje, adicione uma licença de sua preferência.

👤 Autor
Arthur Henry (GitHub)

💬 Contato
Caso tenha dúvidas ou sugestões, abra uma Issue no repositório ou entre em contato diretamente pelo GitHub.

⭐ Se este projeto foi útil, deixe uma estrela!
