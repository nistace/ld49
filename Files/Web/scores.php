<?php

set_include_path("./");
require_once("database/tables/ScoresTable.class.php");

$scoresTable = new ScoresTable();

if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    header('Content-type: application/json');
    echo json_encode($scoresTable->findAll());
    return http_response_code(200);
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $json = file_get_contents('php://input');
    $data = json_decode($json);
    $scoresTable->insert($data->_name, $data->_pacifist, $data->_warmonger);
    return http_response_code(200);
}
