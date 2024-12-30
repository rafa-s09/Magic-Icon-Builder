# Magic-Icon-Builder

Utiliza a biblioteca ImageMagick para converter imagens no formato PNG em arquivos de ícone (ICO). Ele suporta múltiplas resoluções em um único arquivo `.ico` e configurações personalizáveis a partir de um arquivo JSON.

1. Converter arquivos PNG localizados em uma pasta de entrada para ícones.
2. As pastas de entrada e saída, assim como outras configurações relevantes, são lidas de um arquivo JSON chamado `config.json`
3. Por padrão, o programa gera ícones nas seguintes resoluções: `256x256`, `128x128`, `78x78`, `64x64`, `48x48`, `32x32`, `16x16`
