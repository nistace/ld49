<?php

require_once "database/tables/AbstractTable.class.php";
require_once "database/data/Score.class.php";

class ScoresTable extends AbstractTable
{
    public function __construct()
    {
        parent::__construct();
    }

    public function findAll()
    {
        $statement = $this->getConnexion()->prepare("select * from ld49_scores");
        $statement->execute();

        $scores = new ScoreList();
        foreach ($statement->fetchAll() as $row) {
            $scores->Add(new Score($row["sc_name"], $row["sc_pacifist"], $row["sc_warmonger"] ));
        }

        return $scores;
    }

    public function insert($name, $pacifist, $warmonger)
    {
        $statement = $this->getConnexion()->prepare("insert into ld49_scores(sc_name, sc_pacifist, sc_warmonger) VALUES  (:name, :pacifist, :warmonger)");
        $statement->bindParam(":name", $name);
        $statement->bindParam(":pacifist", $pacifist);
        $statement->bindParam(":warmonger", $warmonger);
        $statement->execute();
    }

}
