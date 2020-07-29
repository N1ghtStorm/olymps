fn main() {
    // Например, есть N городов, связаны M{} дорогами нужно найти кратчайший путь из города 1 в город k
    let n = 4;
    let mut matrix = vec![vec![0; n as usize]; n as usize];

    matrix[0][1] = 40;
    matrix[0][3] = 20;
    matrix[1][2] = 5;
    matrix[3][1] = 5;
    matrix[3][2] = 35;

    println!("{:?}", matrix);
}
