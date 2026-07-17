# Bullet

Bullet é um projeto de jogo 2D desenvolvido na Unity. O jogador enfrenta ondas de inimigos enquanto evolui seu personagem através de um sistema de cartas que invocam criaturas companheiras e concedem melhorias durante a partida.

O projeto está sendo desenvolvido com foco em arquitetura modular e sistemas reutilizáveis, permitindo a adição de novas cartas, criaturas e mecânicas com facilidade.

## Tecnologias

- Unity 6
- C#
- Unity Input System

## Funcionalidades implementadas

- Movimentação do jogador
- Mira com o mouse
- Sistema de disparo
- Inimigos com perseguição ao jogador
- Sistema de vida
- Dano por contato
- Game Over
- Reinício da partida
- Barra de vida do jogador
- Sistema de experiência
- Sistema de níveis
- Tela de Level Up
- Sistema de cartas utilizando ScriptableObject
- Invocação de companions
- IA básica dos companions (patrulha e perseguição)

## Em desenvolvimento

- Ataque dos companions
- Diferentes tipos de criaturas
- Sistema de equipamentos
- Evoluções de criaturas
- Salas especiais (rituais, comerciantes e eventos)
- Chefes
- Progressão permanente entre partidas

## Estrutura do projeto

```
Assets/
├── Scripts/
│   ├── Core/
│   ├── Enemy/
│   ├── Managers/
│   ├── Player/
│   ├── Progression/
│   ├── UI/
│   └── Cards/
├── Prefabs/
├── ScriptableObjects/
└── Sprites/
```

## Objetivo

O objetivo é criar um jogo com forte foco em construção de builds, onde cada partida permite montar combinações diferentes de criaturas, equipamentos e melhorias, incentivando experimentação e alta rejogabilidade.

## Status

O projeto está em desenvolvimento ativo.
