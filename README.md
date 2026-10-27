# Minieval Warfare 🛡️⚔️

Un juego de estrategia en tiempo real 2D (*lane-based / tug of war*) desarrollado en **Unity** para la asignatura de Sistemas Multimedia (Grado en Ingeniería Informática, Universidad de Valladolid)[cite: 97, 100].

## 🎮 Descripción del Gameplay
El jugador gestiona recursos (*Arcas Reales*) para desplegar tropas especializadas a través de múltiples filas en un campo de batalla 2D. El objetivo es superar las líneas enemigas y empujar el medidor de victoria antes de que se agote el tiempo límite[cite: 100, 102, 105].

## ✨ Características Técnicas & Mecánicas
*   **Sistema de Invocación por Carriles (Lanes):** Lógica de IA básica para detección de colisiones, paradas ante aliados y selección de objetivos fijos en combate cuerpo a cuerpo y a distancia[cite: 106].
*   **Economía Progresiva:** Generación de oro escalonada para evitar estancamientos y forzar decisiones tácticas bajo presión[cite: 105].
*   **Control Dual:** Soporte para un jugador (con WASD + Espacio + Movimiento de cámara por ratón) y modo local PvP (Jugador vs Jugador dividiendo el teclado)[cite: 102, 106].
*   **Gestión de Audio y UI:** Integración de sistemas de menús pausables, efectos de sonido (SFX) y música ambiental en bucle[cite: 111, 114].

## 🕹️ Demostración
![Gameplay Principal](./Imagenes/MinievalWarfare.gif)
*Despliegue de tropas y combate en tiempo real.*

## 📂 Documentación
Puedes consultar el **Game Design Document (GDD)** completo del proyecto en la carpeta [Docs](./Docs/GDD_MinievalWarfare.pdf), donde se detallan el diseño de niveles, balanceo de estadísticas de las 12 tropas y el análisis legal de los assets de libre uso (*Itch.io*)[cite: 98, 101, 105].

## 🛠️ Entorno de Desarrollo
*   **Motor:** Unity (versión 6 / compatible con pipelines 2D).
*   **Lenguaje:** C# (Arquitectura basada en componentes y scripts modulares para `Units`, `GameManagers` y `Menus`).