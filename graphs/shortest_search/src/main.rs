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

    let mut shortest_len = 0;
    let mut shortest_path_nodes = vec![0];

    for i in 0..4 {
        let mut shortest_path_i_nodes = vec![(0, 0)];
        let mut shortest_town_i = (0, 0);

        for j in 0..4 {
            if matrix[i][j] != 0 {
                // /println!("{:?}", matrix[i][j]);
                shortest_path_i_nodes.push((j, matrix[i][j]));
            }
        }

        //let a = shortest_path_i_nodes.Map().iter().min()
    }
}
