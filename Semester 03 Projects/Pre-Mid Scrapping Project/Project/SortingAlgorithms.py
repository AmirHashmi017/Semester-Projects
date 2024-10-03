import sys
sys.setrecursionlimit(1500)  
def BubbleSort(array,start, end):
    for i in range(start,end-1,1):

        for j in range(start,end-i-1,1):
            
            if(array[j]>array[j+1]):
                array[j],array[j+1]=array[j+1],array[j]
    return array

def SelectionSort(array,start, end):
    for i in range(start,end-1,1):
        minimumindex=i
        for j in range(i+1,end,1):
            if(array[j]<array[minimumindex]):
                minimumindex=j
        array[i],array[minimumindex]=array[minimumindex],array[i]
    return array

def InsertionSort(array,start, end):
    for i in range(start+1,end,1):
        key=array[i]
        j=i-1
        while j>=start and array[j]>key:
            array[j+1]=array[j]
            j=j-1
        array[j+1]=key
    return array

def MergeSort(array,start,end):
    n=end-start
    if(n<=0):
        return
    mid=int((start+end)/2)
    MergeSort(array,start,mid)
    MergeSort(array,mid+1,end)
    Merge(array,start,mid+1,end)

def HybridMergeSort(array,start,end,n=6):
    if(end-start<=n):
        InsertionMergeSort(array,start,end)
    else:
        mid=int((start+end)/2)
        HybridMergeSort(array,start,mid)
        HybridMergeSort(array,mid+1,end)
        Merge(array,start,mid+1,end)

def QuickSort(Arr, start, end):
    while start < end:
        if end - start < 10:
            InsertionSort(Arr, start, end)
            break
        else:
            pivot = Partition(Arr, start, end)
            if pivot - start < end - pivot:
                QuickSort(Arr, start, pivot - 1)
                start = pivot + 1
            else:
                QuickSort(Arr, pivot + 1, end)
                end = pivot - 1

def Partition(Arr,start,end):
    endpivot=Arr[end-1]
    i=start-1
    for j in range(start,end-1,1):
        if(Arr[j]<=endpivot):
            i+=1
            Arr[i],Arr[j]=Arr[j],Arr[i]
    Arr[i+1],Arr[end-1]=Arr[end-1],Arr[i+1]
    return i+1

def CountingSort(inputarray):
    minimumvalue = min(inputarray)
    maximumvalue = max(inputarray)
    
    elementsrange = maximumvalue - minimumvalue + 1
    count = [0] * elementsrange
    output = [0] * len(inputarray)

    for i in range(0,len(inputarray),1):
        shiftedvalue = inputarray[i] - minimumvalue
        count[shiftedvalue] += 1

    for i in range(1, len(count),1):
        count[i] += count[i - 1]

    for i in range(len(inputarray) - 1, -1, -1):
        shiftedvalue = inputarray[i] - minimumvalue
        count[shiftedvalue] -= 1
        output[count[shiftedvalue]] = inputarray[i]

    return output


def RadixSort(inputarray):
    maximumvalue = max(inputarray)
    significant = 1
    while maximumvalue // significant > 0:
        CountingSortForRadix(inputarray, significant)
        significant *= 10  
    return inputarray

def CountingSortForRadix(inputarray, significant):
    count = [0] * 10
    output = [0] * len(inputarray)

    for i in range(len(inputarray)):
        digit = (inputarray[i] // significant) % 10
        count[digit] += 1

    for i in range(1, 10):
        count[i] += count[i - 1]

    for i in range(len(inputarray) - 1, -1, -1):
        digit = (inputarray[i] // significant) % 10
        count[digit] -= 1
        output[count[digit]] = inputarray[i]

    for i in range(len(inputarray)):
        inputarray[i] = output[i]


def BucketSort(Arr):
    n = len(Arr)
    buckets = [[] for i in range(n)]

    for i in range(n):
        index = int(Arr[i] * 2)
        buckets[index].append(Arr[i])

    for i in range(n):
        buckets[i] = InsertionSort(buckets[i],0,len(buckets[i]))
    output = []
    for i in range(n):
        output.extend(buckets[i])
    
    return output


def pigeonhole_sort(array):
    min_value = min(array)
    max_value = max(array)

    size = max_value - min_value + 1
    holes = [[] for _ in range(size)]

    for number in array:
        holes[number - min_value].append(number)

    sorted_array = []
    for hole in holes:
        sorted_array.extend(hole)

    return sorted_array



def CycleSort(arr):
    writes = 0
    for cycle_start in range(0, len(arr) - 1):
        item = arr[cycle_start]

        pos = cycle_start
        for i in range(cycle_start + 1, len(arr)):
            if arr[i] < item:
                pos += 1

        if pos == cycle_start:
            continue

        while item == arr[pos]:
            pos += 1
        arr[pos], item = item, arr[pos]
        writes += 1

        while pos != cycle_start:
            pos = cycle_start
            for i in range(cycle_start + 1, len(arr)):
                if arr[i] < item:
                    pos += 1

            while item == arr[pos]:
                pos += 1
            arr[pos], item = item, arr[pos]
            writes += 1

    return arr



def TimSort(array):
    min_run = 32

    for start in range(0, len(array), min_run):
        end = min(start + min_run - 1, len(array) - 1)
        InsertionMergeSort(array, start, end)

    size = min_run
    while size < len(array):
        for left in range(0, len(array), 2 * size):
            mid = min(left + size - 1, (len(array) - 1))
            right = min((left + 2 * size - 1), (len(array) - 1))
            if mid < right:
                Merge(array, left, mid + 1, right)

        size *= 2

def Merge(array, p, q, r):
    LeftArray = array[p:q]
    RightArray = array[q:r + 1]
    mergedindex = p
    i = 0
    j = 0

    while i < len(LeftArray) and j < len(RightArray):
        if LeftArray[i] <= RightArray[j]:
            array[mergedindex] = LeftArray[i]
            i += 1
        else:
            array[mergedindex] = RightArray[j]
            j += 1
        mergedindex += 1

    while i < len(LeftArray):
        array[mergedindex] = LeftArray[i]
        i += 1
        mergedindex += 1

    while j < len(RightArray):
        array[mergedindex] = RightArray[j]
        j += 1
        mergedindex += 1

def InsertionMergeSort(array, start, end):
    for i in range(start + 1, end + 1, 1):
        key = array[i]
        j = i - 1
        while j >= start and array[j] > key:
            array[j + 1] = array[j]
            j -= 1
        array[j + 1] = key

