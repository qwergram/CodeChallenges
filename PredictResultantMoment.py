def rot_pred(arr):
    left_side, right_side = arr[:arr.index('S')][::-1], arr[arr.index('S') + 1:]
    if len(left_side) == len(right_side):
        forces = [0, 0]
        for i, side in enumerate([left_side, right_side]):
            for multiplier, force in enumerate(side):
                forces[i] += (multiplier + 1) * force
        if forces[0] > forces[1]:
            return 'anti clockwise'
        elif forces[1] > forces[0]:
            return 'clockwise'
        return 'steady'
    return 'Not a Valid Entry'
