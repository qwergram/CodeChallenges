def exp_sum(n):
    if n >= 0:
        ways = [1]+[0]*n
        for num in range(1,n+1):
            for i in range(num,n+1):
                ways[i] += ways[i-num]
        return ways[-1]
    return 0
