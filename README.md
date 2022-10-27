# Object-Pool
Here are 3 variations of my object pool:
1) Static pool - A pool that creates an array of the specified size and works strictly within its limits. During initialization, creates an array of the specified size and fills it with the created items. If it does not find an item, it returns the first element of the array.
2) Dynamic pool - A pool that creates items strictly as needed. During initialization, it also accepts the one it will work with. If the search for an element fails, it creates a new one and returns it.
3) Combined pool - A pool combining the two previous pools. During initialization, creates a List<T> with the specified size and fills it with the created items. Increases its size as needed by creating new items
