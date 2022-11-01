'''One of the motivating problems for this project is finding the shortest number of moves needed to solve variants of the Towers of Hanoi puzzle. The classic puzzle, with 3 stacks and *n* discs, can be solved in 2^n-1 moves. We want to find similar formulae for stack sizes other than 3.'''

def create_board(stacks, discs):
    '''create the initial puzzle state'''
    return tuple((tuple(i for i in range(discs)) if j == 0 else () for j in range(stacks)))

