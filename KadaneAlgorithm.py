def KadaneAlgorithm(array):
    if array:
        largest_record = largest_so_far = array[0]
        for i, number in enumerate(array):
            largest_so_far = max(sum(array[:i+1]), number)
            largest_record = max(largest_record, largest_so_far)
        return largest_record
