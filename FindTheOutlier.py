def find_outlier(integers):
    history = [[0, None], [0, None]]
    for number in integers:
        i = number % 2
        if history[i][0] + 1 >= 2 and history[1-i][1]:
            return history[1-i][1]
        history[i] = [history[i][0] + 1, number]
    return min(history, key=lambda x: x[0])[1]
