<?php


class ScoreList
{
    public $_entries;

    public function __construct()
    {
        $this->_entries = [];
    }

    public function Add($entry)
    {
        array_push($this->_entries, $entry);
    }
}

class Score
{
    public $_name;
    public $_pacifist;
    public $_warmonger;

    public function __construct($name, $pacifist, $_warmonger)
    {
        $this->_name = $name;
        $this->_pacifist = $pacifist;
        $this->_warmonger = $_warmonger;
    }
}
