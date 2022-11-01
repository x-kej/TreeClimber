# TreeClimber
A library for solving certain kinds of shortest-path problems.

## Overview

This is an adaptation of a breadth-first graph search function, but for the situation when the layout of the graph is not necessarily known ahead of time. Instead of enumerating the entire graph structure before searching, we can begin at a known starting node, enumerate the adjacent nodes, and then visit each of those.

By making sure that we visit nodes in the order they were discovered, and by not returning to previously visited nodes, we can guarantee that the path we find to a node meeting any given criteria will be *a* (not necessarily *the only*) shortest path from beginning to destination.

Some applications of this technique will be added after the library is built.
