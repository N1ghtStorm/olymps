process.stdin.resume();
process.stdin.setEncoding('utf8');

var input = '', readline, print;

process.stdin.on('data', function (chunk) {
    input += chunk;
});

process.stdin.on('end', function () {
    input = input.split('\n');
    print = function (data) { process.stdout.write(data + '\n') };
    var inputLineIndex = 0;
    readline = function () { return inputLineIndex >= input.length ? undefined : input[inputLineIndex++] };
    process.exit(main() || 0);
});

function main() {
    // Your code here
    let n = readline().split(" ").map(x => parseInt(x));
    let fArray = readline().split(" ").map(x => parseInt(x));

    let matrixArray = new Array();

    for (i = 0; i < n; i++) {
        matrixArray.push(new Array(n).fill(0));
    }

    for (i = 0; i < n; i++) {
        matrixArray[i][fArray[i] - 1] = 1
    }

    // Алгоритм:

    // bool;
    let isHavingTriangles = false;
    for (let a = 0; a < n; a++) {

        if (isHavingTriangles) {
            break;
        }

        for (let b = a + 1; b < n; b++) {

            if (isHavingTriangles) {
                break;
            }

            if (matrixArray[a][b] === 0) {
                continue;
            }

            for (let c = 0; c < n; c++) {

                if (matrixArray[c][a] === 1 && matrixArray[b][c] === 1) {
                    console.log('YES');
                    isHavingTriangles = true;
                    break;
                }
            }
        }
    }

    if (isHavingTriangles === false) {
        console.log('NO');
    }
    return 0;
}